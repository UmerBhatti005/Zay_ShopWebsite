import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SignInUser } from 'src/app/Model/SignInUser';
import { AccountService } from 'src/app/Services/account.service';
import { NonVolatileService } from 'src/app/Services/non-volatile.service';
import { SharedDataService } from 'src/app/Services/shared-data.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup = new FormGroup({
    username: new FormControl(null, [Validators.required]),
    password: new FormControl(null, [Validators.required]),
  });

  SignInUser = new SignInUser();
  istrue: boolean = false;
  islogin = false;

  constructor(private router: Router,
    private accountService: AccountService,
    private nonVolatile: NonVolatileService,
    private shareddata: SharedDataService) { }

  ngOnInit(): void {
  }


  PostSignInUser() {
    if (!this.loginForm.valid) {
      return;
    }
    this.accountService.PostSignInUser(this.SignInUser).subscribe({
      next: (data) => {
        debugger;
        this.nonVolatile.SetDataToLocalStorage(data);
        this.router.navigate(['index'])
        this.islogin = true;
        // location.reload();
        console.log(data);
      },
      error: (e) => {
        console.log("Error", e);
      }
    })
  }

  Login() {
    this.PostSignInUser();
    this.shareddata.changeMessage(this.islogin);
  }

}
