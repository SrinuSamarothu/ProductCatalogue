import { Component, } from '@angular/core';
import {MatExpansionModule} from '@angular/material/expansion';
import { CategoriesService } from './categories.service';
import { MatDialog } from '@angular/material/dialog';
import { AddCategoryComponent } from '../add-category/add-category.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent {
  list = [1, 2, 3, 4]
  categories : Category[] = []

  constructor(private categoryService : CategoriesService, private dialog : MatDialog,
    private router: Router) {}

  ngOnInit() {
    this.categoryService.getCategories().subscribe(data => {
      console.log(data);
      this.categories = data;
    })
  }

  removeCategory(category : Category) {
    this.categoryService.removeCategory(category).subscribe(data => {
      if(data != null){
        alert(`Category ${category.name} is deleted.`);
        let index = this.categories.indexOf(category, 0);
        this.categories.splice(index, 1);
      }
      else{
        alert(`Something went wrong while deleting.`);
      }
    })
  }

  openAddDialog(enterAnimationDuration: string, exitAnimationDuration: string): void {
    this.dialog.open(AddCategoryComponent, {
      width: '600px',
      enterAnimationDuration,
      exitAnimationDuration,
    });
  }

  getProducts(catId : string) {
    this.router.navigate(['view-products', catId])
  }

  modifyCategory(catId : string){
    this.router.navigate(['modify-category', catId])
  }
}


export interface Category{
  categoryId : string,
  name :  string,
  description : string
}