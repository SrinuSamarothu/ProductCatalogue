import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Category } from '../categories/categories.component';
import { Guid } from 'guid-typescript';
import { CategoriesService } from '../categories/categories.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent {

  constructor(private fb: FormBuilder, private categoryService : CategoriesService, private router: Router) {}

  categoryForm!: FormGroup;
  catId = Guid.create()
  ngOnInit(): void {
  }

  category !: Category 

  AddCategory(catName: string, catDesc: string) {
    this.category = {
      categoryId : this.catId.toString(),
      name : catName,
      description : catDesc
    }

    this.categoryService.addCategory(this.category).subscribe(data => {
      if(data != null){
        alert(`New category ${data.name} is added`);
        window.location.reload();
        // this.router.navigate(['categories'])
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
