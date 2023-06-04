import { Injectable } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Category } from './categories.component';
import { catchError, Observable, scheduled } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {

  constructor(private http : HttpClient) { }

  getCategories() {
    return this.http.get<Category[]>('https://localhost:44384/api/Category/GetAll');
  }

  removeCategory(cat : Category) {
    return this.http.delete<Category>('https://localhost:44384/api/Category/Delete', {body : cat});
  }

  addCategory(cat : Category) {
    return this.http.post<Category>('https://localhost:44384/api/Category/Add', cat)
  }

  updateCategory(cat : Category) {
    return this.http.put<Category>('https://localhost:44384/api/Category/Update', cat);
  }

  // ---------- Products

  getProducts(catId : string) {
    return this.http.get<Product[]>(`https://localhost:44384/api/Products/GetAll?categoryId=${catId}`)
  }

  addProduct(product : Product) {
    return this.http.post<Product>('https://localhost:44384/api/Products/Add', product)
  }

  removeProduct(product : Product) {
    return this.http.delete<Product>('https://localhost:44384/api/Products/Delete', {body : product})
  }

  updateProduct(product : Product) {
    return this.http.put<Product>('https://localhost:44384/api/Products/Modify', product);
  }

  // -------------- Attributes

  getAttributes(proId : string) {
    return this.http.get<ProductAttribute[]>(`https://localhost:44384/api/ProductAttributes/GetAll?productId=${proId}`);
  }

  addAttribute(att : ProductAttribute) {
    return this.http.post<ProductAttribute>('https://localhost:44384/api/ProductAttributes/Add', att)
  }

  removeAttribute(att : ProductAttribute) {
    return this.http.delete<ProductAttribute>('https://localhost:44384/api/ProductAttributes/Delete', {body : att})
  }

  modifyAttribute(att : ProductAttribute) {
    return this.http.put<ProductAttribute>('https://localhost:44384/api/ProductAttributes/Modify', att)
  }

}


export interface Product {
    productId : string,
    name : string,
    brand : string,
    price : number,
    quantity : number,
    description : string,
    categoryId : string
}

export interface ProductAttribute {
  attributeId : string,
  name : string,
  value : string,
  productId : string
}