import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, throwError } from 'rxjs';
import { CartSystem } from '../Model/CartSystem';

@Injectable({
  providedIn: 'root'
})
export class CartSystemService {

  constructor(private http: HttpClient) { }

  Url =  "https://localhost:44310/api/CartSystem";
  UserCart = "https://localhost:44310/FromUser";
  Delivered = "https://localhost:44310/api/CartSystem?active=true";
  reportno3_Cart = "https://localhost:44310/FromUser/Umer786?active=true";

  GetCartSystem(){
    return this.http.get<any>(this.Url).pipe(catchError(this.errorHandler));
  }

  GetCartSystemById(id:any){
    return this.http.get<any>(`${this.Url}/${id}`).pipe(catchError(this.errorHandler));
  }

  Getreportno3_Cart(){
    return this.http.get<any>(this.reportno3_Cart).pipe(catchError(this.errorHandler));
  }

  GetCartSystemByUsername(Username: string){
    return this.http.get<any>(`${this.UserCart}/${Username}`).pipe(catchError(this.errorHandler));
  }

  GetDeliveredCartSystem(){
    return this.http.get<any>(this.Delivered).pipe(catchError(this.errorHandler));
  }

  PostCategory(data: any) {
    return this.http.post(this.Url, data).pipe(catchError(this.errorHandler));
  }

  PutCartSystem(data: any) {
    return this.http.put<CartSystem>(this.Url, data).pipe(catchError(this.errorHandler));
  }

  DeleteCartSystem(id: any) {
    return this.http.delete(this.Url + '/?id=' + id).pipe(catchError(this.errorHandler));
  }

  errorHandler(error: HttpErrorResponse) {
    return throwError(() => error);
  }
}
