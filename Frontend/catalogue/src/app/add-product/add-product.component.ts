import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Category } from '../categories/categories.component';
import { Guid } from 'guid-typescript';
import { CategoriesService, Product } from '../categories/categories.service';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent {

  constructor(private router : Router, private activatedRoute : ActivatedRoute,
    private categoryService : CategoriesService) {}

  catId !: string
  product !: Product

  ngOnInit() {
    this.activatedRoute.params.subscribe(data => {
      this.catId = data['id']
    })
  }

  AddProduct(proName: string, proBrand: string, proPrice : string, proQuantity : string, proDescription : string) {
    let proId : Guid = Guid.create()
    this.product = {
      productId : proId.toString(),
      name : proName,
      brand : proBrand,
      price : Number(proPrice),
      quantity : Number(proQuantity),
      description : proDescription,
      categoryId : this.catId 
    }
    this.categoryService.addProduct(this.product).subscribe(data => {
      if(data != null) {
        alert(`Product '${data.name}' added succesfully`);
        window.location.reload();
      }
      else{
        alert('Something went wrong');
        this.router.navigate(['view-products', this.catId])
      }
    })
  }

  GoBack() {
    this.router.navigate(['view-products', this.catId]);
  }
}
