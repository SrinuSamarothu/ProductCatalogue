import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddCategoryComponent } from './add-category/add-category.component';
import { AddProductComponent } from './add-product/add-product.component';
import { CategoriesComponent } from './categories/categories.component';
import { ModifyCategoryComponent } from './modify-category/modify-category.component';
import { ModifyProductComponent } from './modify-product/modify-product.component';
import { ShowAttributesComponent } from './show-attributes/show-attributes.component';
import { ViewProductsComponent } from './view-products/view-products.component';


const routes: Routes = [
  {
    path: '', redirectTo: '/categories', pathMatch: 'full'
  },
  {
    path: 'categories', component: CategoriesComponent
  },
  {
    path: 'view-products/:id', component: ViewProductsComponent 
  },
  {
    path : 'modify-category/:id', component : ModifyCategoryComponent
  },
  {
    path : 'modify-product/:proId/:catId', component : ModifyProductComponent
  },
  {
    path : 'add-product/:id', component : AddProductComponent
  },
  {
    path : 'show-attributes/:proId/:proName', component : ShowAttributesComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
