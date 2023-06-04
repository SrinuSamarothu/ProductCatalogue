import { Component } from '@angular/core';
import { Category } from '../categories/categories.component';
import { Guid } from 'guid-typescript';
import { CategoriesService } from '../categories/categories.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../categories/categories.service';

@Component({
  selector: 'app-modify-product',
  templateUrl: './modify-product.component.html',
  styleUrls: ['./modify-product.component.css']
})
export class ModifyProductComponent {

  constructor(private categoryService : CategoriesService, 
    private router: Router, private activatedRoute : ActivatedRoute) {}

  // categoryForm!: FormGroup;
  proId !: string ;
  catId !: string;
  oldProduct !: Product
  

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(data => {
      this.proId = data['proId']
      this.catId = data['catId']
      console.log(this.proId)
      console.log(this.catId)
    })
    console.log(this.proId);
    this.categoryService.getProducts(this.catId).subscribe(res => {
      if( res != null) {
        res.forEach(element => {
          if(element.productId == this.proId) {
            this.oldProduct = element
          }
        });
      }
    })
  }

  ModifyProduct(proName: string | null, proBrand: string | null, proPrice : string | null, proQuantity : string | null, proDescription : string | null) {
    
    let product : Product =  {
      productId : this.proId,
      name : (proName != null && proName != '') ? proName : this.oldProduct.name,
      brand : (proBrand != null && proBrand != '') ? proBrand : this.oldProduct.brand,
      price : (proPrice != null && proPrice != '') ? Number(proPrice) : Number(this.oldProduct.price),
      quantity : (proQuantity != null && proQuantity != '') ? Number(proQuantity) : Number(this.oldProduct.quantity),
      description : (proDescription != null && proDescription != '') ? proDescription : this.oldProduct.description,
      categoryId : this.catId,
    }

    this.categoryService.updateProduct(product).subscribe(data => {
      if(data != null){
        alert(`Category got modified`);
        this.router.navigate(['view-products', this.catId])
      }
      else{
        alert("Something went wrong while adding category");
      }
    })
  }

  GoBack() {
    this.router.navigate(['view-products', this.catId]);
  }
}
