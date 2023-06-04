import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoriesService, Product } from '../categories/categories.service';
import { MatDialog } from '@angular/material/dialog';
import { AddProductComponent } from '../add-product/add-product.component';

@Component({
  selector: 'app-view-products',
  templateUrl: './view-products.component.html',
  styleUrls: ['./view-products.component.css']
})
export class ViewProductsComponent {

  constructor(private categoryService : CategoriesService, private activatedRoute : ActivatedRoute,
    private router : Router, ) {}

  products : Product[] = []
  catId !: string
  count : number = 0


  ngOnInit() {
    this.activatedRoute.params.subscribe(parameters => {
      this.catId = parameters['id'] 
    })
    this.categoryService.getProducts(this.catId).subscribe(data => {
      if(data != null) {
        this.products = data
        this.count = this.products.length
        console.log(this.products)
      }
      else {
        alert("Something went wrong")
      }
    })
  }

  AddProduct() {
    this.router.navigate(['add-product', this.catId])
  }

  RemoveProduct(pro : Product) {
    this.categoryService.removeProduct(pro).subscribe(data => {
      if(data != null) {
        alert(`Product '${pro.name}' got deleted`);
        let index = this.products.indexOf(pro);
        this.products.splice(index, 1);
        this.count = this.products.length
      }
      else{
        alert('Something went wrong');
      }
    })
  }

  gotoShowAttributes(proId : string, proName : string) {
    this.router.navigate(['show-attributes', proId, proName])
  }

  gotoModifyProduct(proId : string) {
    this.router.navigate(['modify-product', proId, this.catId])
  }
}
