import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ThemePalette } from '@angular/material/core';
import { Router } from '@angular/router';
import { Observable, ReplaySubject } from 'rxjs';
import { CustomValidatorsService } from 'src/app/Helpers/custom-validators.service';
import { Role } from 'src/app/Model/Role';
import { User } from 'src/app/Model/SignUpUser';
import { AccountService } from 'src/app/Services/account.service';
import { AdministratorService } from 'src/app/Services/administrator.service';
import { NotificationService } from 'src/app/Services/notification.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  User = new User();
  roles: any = [];
  role: any;
  roleforuser: any;
  files: any;

  fileControl: FormControl;

  istrue: boolean = false;
  constructor(private accountService: AccountService,
    private administratorService: AdministratorService,
    private notificationService: NotificationService) {
  }

  ngOnInit(): void {
    this.GetRoles();
  }

  registerForm = new FormGroup({
    email: new FormControl(null, [Validators.required, Validators.email]),
    username: new FormControl(null, [Validators.required]),
    firstname: new FormControl(null, [Validators.required]),
    lastname: new FormControl(null, [Validators.required]),
    password: new FormControl(null, [Validators.required]),
    passwordConfirm: new FormControl(null, [Validators.required]),
    role: new FormControl(null, [Validators.required]),
    Image: new FormControl(null, [Validators.required])
  },
    // add custom Validators to the form, to make sure that password and passwordConfirm are equal
    { validators: CustomValidatorsService.passwordsMatching }
  )

  PostUser() {
    this.role = this.roleforuser;
    this.accountService.PostSignUpUser(this.User)
      .subscribe({
        next: (data) => {
          console.log(data);
          // this.router.navigate(['/users/login'])
          this.notificationService.showInfo("Email sent on your Gmail Account", "Email Sent");
        }, error: (e: Response) => {
          // alert("Error" + e)
          this.notificationService.showError(e.text.toString(), e.formData.toString());
        }
      })
  }

  save() {
    this.PostUser();
  }

  GetRoles() {
    this.administratorService.GetAllRoles().subscribe({
      next: (data) => {
        console.log(data);
        this.roles = data;
      }, error: (e: Response) => {
        alert("Error: " + e.text);
      }
    });
  }

  onFileSelected(event: any) {
    for (let i = 0; i < this.onFileSelected.length; i++) {
      this.convertFile(event.target.files[i]).subscribe(base64 => {
        console.log(base64);
        this.User.image = base64;
      });
    }

  }
  convertFile(file: File): Observable<string> {
    const result = new ReplaySubject<string>(1);
    const reader = new FileReader();
    reader.readAsBinaryString(file);
    reader.onload = (event: any) => result.next(btoa(event.target.result.toString()));
    return result;
  }

}
