import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { Category } from '../Model/Category';

@Injectable({
  providedIn: 'root'
})
export class GeneralService {

  constructor(private http: HttpClient) { }

  Geturl = "https://localhost:44310/api/General";
  topLevelUrl = "https://localhost:44310/api/General?top=true";
  SubCategory = "https://localhost:44310/api/General?subCat=";
  sub = "https://localhost:44310/api/General?sub=true";


  category: Category = new Category();

  GetCategories() {
    return this.http.get<any>(this.Geturl).pipe(catchError(this.errorHandler));
  }

  GetSubCategories(){
    return this.http.get<any>(this.sub).pipe(catchError(this.errorHandler))
  }

  GetTopLevelCategory() {
    return this.http.get<any>(this.topLevelUrl).pipe(catchError(this.errorHandler))
  }

  GetSubcategory(id: any) {
    return this.http.get<any>(`${this.SubCategory}${id}`).pipe(catchError(this.errorHandler))
  }

  PostCategory(data: any) {
    return this.http.post(this.Geturl, data).pipe(catchError(this.errorHandler));
  }

  PutCategory(data: any) {
    this.http.put(`${this.Geturl}${data.id}`, data).pipe(catchError(this.errorHandler));
  }

  DeleteCategory(id: any) {
    this.http.delete(this.Geturl, id).pipe(catchError(this.errorHandler));
  }
  errorHandler(error: HttpErrorResponse) {
    return throwError(() => error);
  }

}
