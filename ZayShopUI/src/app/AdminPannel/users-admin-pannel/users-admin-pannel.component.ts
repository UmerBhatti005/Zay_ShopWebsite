import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subject } from 'rxjs';
import { User } from 'src/app/Model/SignUpUser';
import { AccountService } from 'src/app/Services/account.service';

@Component({
  selector: 'app-users-admin-pannel',
  templateUrl: './users-admin-pannel.component.html',
  styleUrls: ['./users-admin-pannel.component.css']
})
export class UsersAdminPannelComponent implements OnInit {

  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<any> = new Subject<any>();
  users: any;

  constructor(private accountService: AccountService,
    private spinnerService: NgxSpinnerService) { }

  ngOnInit(): void {
    this.GetUsers();
  }

  GetUsers() {
    this.spinnerService.show();
    this.accountService.GetUsers().subscribe({
      next: (data) => {
        console.log(data);
        this.users = data;
        this.spinnerService.hide();
        this.dtTrigger.next(data);
      }
    })
  }
}
