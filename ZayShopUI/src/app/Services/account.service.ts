import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, throwError } from 'rxjs';
import { SignInUser } from '../Model/SignInUser';
import { User } from '../Model/SignUpUser';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private http: HttpClient) { }

  SignUpUrl = "https://localhost:44310/api/Account/signup";
  SignInUrl = "https://localhost:44310/api/Account/login";
  GetUser = "https://localhost:44310/api/Account/";
  GetUsersUrl = "https://localhost:44310/users";

  PostSignUpUser(user: User){
    const headers = { 'content-type': 'application/json'}  
    const body=JSON.stringify(user);
    console.log(body);
    return this.http.post(this.SignUpUrl, body, {'headers':headers}).pipe(catchError(this.errorHandler));
  }


  PostSignInUser(SignInUser: any){
    const headers = {'content-type': 'application/json'}  
    console.log(SignInUser);
    return this.http.post(this.SignInUrl, SignInUser, {'headers':headers}).pipe(catchError(this.errorHandler));
  }

  GetUsers(){
    return this.http.get(this.GetUsersUrl).pipe(catchError(this.errorHandler));
  }

  GetUserByUsername(username: any){
    return this.http.get<User>(this.GetUser + username).pipe(catchError(this.errorHandler));
  }

  errorHandler(error:HttpErrorResponse){
    return throwError( () => error);
  }

}
