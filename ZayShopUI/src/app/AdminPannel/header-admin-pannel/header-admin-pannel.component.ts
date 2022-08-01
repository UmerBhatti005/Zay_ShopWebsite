import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/Model/SignUpUser';
import { AccountService } from 'src/app/Services/account.service';
import { NonVolatileService } from 'src/app/Services/non-volatile.service';

@Component({
  selector: 'app-header-admin-pannel',
  templateUrl: './header-admin-pannel.component.html',
  styleUrls: ['./header-admin-pannel.component.css']
})
export class HeaderAdminPannelComponent implements OnInit {

  username: string;
  admin: any;

  constructor(private nonVolatile: NonVolatileService,
    private accountService: AccountService) { }

  ngOnInit(): void {

    this.GetUser();
    this.GetAdmin();
  }

  GetUser() {
    this.username = this.nonVolatile.GetDataToLocalStorage().username;
  }
  GetAdmin() {
    this.accountService.GetUserByUsername(this.username).subscribe({
      next: (data) => {
        this.admin = data;
      }
    })
  }

}
