import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, throwError } from 'rxjs';
import { Product } from '../Model/Product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  // products:Product[];
  // product:Product = new Product();

  constructor(private http: HttpClient) { }

  GetUrl = "https://localhost:44310/api/products?active=true";
  SpecuserUrl =  "https://localhost:44310/SpecAdv/";
  FeaturedProduct = "https://localhost:44310/api/products?featured=true";
  UrlForAdmin = "https://localhost:44310/api/products";
  ProductByIdURL = "https://localhost:44310/api/Products";
  

  GetProduct(){
    return this.http.get<any>(this.GetUrl).pipe(catchError(this.errorHandler));
  }

  GetProductById(id: any){
    return this.http.get<Product>(`${this.ProductByIdURL}/${id}`).pipe(catchError(this.errorHandler));
  }

  GetProductsForAdmin(){
    return this.http.get<any>(this.UrlForAdmin).pipe(catchError(this.errorHandler));
  }

  GetSpecificAdvFromUser(username: any){
    return this.http.get<any>(this.SpecuserUrl + username).pipe(catchError(this.errorHandler));
  }
  

  GetFeaturedProduct(){
    return this.http.get<any>(this.FeaturedProduct).pipe(catchError(this.errorHandler));
  }

  PostProduct(product: Product){
    const headers = { 'content-type': 'application/json'}  
    const body=JSON.stringify(product);
    console.log(body);
    return this.http.post(this.GetUrl, body, {'headers':headers}).pipe(catchError(this.errorHandler)); 
  }

  UpdateProduct(data:any){
    return this.http.put(this.UrlForAdmin, data).pipe(catchError(this.errorHandler));
  }

  DeleteProduct(){
    return this.http.delete(this.GetUrl).pipe(catchError(this.errorHandler));
  }

  errorHandler(error:HttpErrorResponse){
    return throwError(() => error);
  }

}
