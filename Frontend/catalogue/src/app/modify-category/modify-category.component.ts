import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Category } from '../categories/categories.component';
import { Guid } from 'guid-typescript';
import { CategoriesService } from '../categories/categories.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-modify-category',
  templateUrl: './modify-category.component.html',
  styleUrls: ['./modify-category.component.css']
})
export class ModifyCategoryComponent {

  constructor(private fb: FormBuilder, private categoryService : CategoriesService, 
    private router: Router, private activatedRoute : ActivatedRoute) {}

  // categoryForm!: FormGroup;
  catId !: string ;
  oldCategory !: Category 
  

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(data => this.catId = data['id'])
    console.log(this.catId);
    this.categoryService.getCategories().subscribe(res => {
      if( res != null) {
        res.forEach(element => {
          if(element.categoryId == this.catId) {
            this.oldCategory = element
          }
        });
      }
    })
  }
  category !: Category 


  ModifyCategory(catName: string, catDesc: string) {
    console.log(catName)
    console.log(catDesc)
    this.category = {
      categoryId : this.oldCategory.categoryId,
      name : (catName != null && catName != '') ? catName : this.oldCategory.name,
      description : (catDesc != null && catDesc != '') ? catDesc : this.oldCategory.description
    }

    this.categoryService.updateCategory(this.category).subscribe(data => {
      if(data != null){
        alert(`Category got modified`);
        this.router.navigate(['categories'])
      }
      else{
        alert("Something went wrong while adding category");
      }
    })
  }

  GoBack() {
    this.router.navigate(['categories']);
  }
}
