import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ImportantService {

  getColorsUrl = "https://localhost:44310/api/products?colors=true";
  getProductSizes = "https://localhost:44310/api/General?productsize=true";
  constructor(private http: HttpClient) {
   }

   GetColors(){
    return this.http.get<any>(this.getColorsUrl).pipe(catchError(this.errorHandler));
   }
  
   GetProductSizes(){
    return this.http.get<any>(this.getProductSizes).pipe(catchError(this.errorHandler));
   }

   errorHandler(error:HttpErrorResponse){
    return throwError(() => error);
  }
  
}
