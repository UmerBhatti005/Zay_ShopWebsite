import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NonVolatileService } from 'src/app/Services/non-volatile.service';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent implements OnInit {

  constructor(
    private router: Router,
    private nonVolatile: NonVolatileService
) {
    // redirect to home if already logged in
    if (this.nonVolatile.GetDataToLocalStorage()?.tokenOption?.length > 0) {
        this.router.navigate(['/']);
    }
}

ngOnInit(): void {
}

}
