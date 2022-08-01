import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AccountService } from '../Services/account.service';
import { NonVolatileService } from '../Services/non-volatile.service';


@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate {

  constructor(
    private router: Router,
    private nonVolatile: NonVolatileService
  ) { }

  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    const user = this.nonVolatile.userValue;

    if (user?.tokenOptions?.length > 0) {
      // authorised so return true
      return true;
    }
    // not logged in so redirect to login page with the return url
    this.router.navigate(['/users/login']);
    // this.router.navigate(['/users/login'], { queryParams: { returnUrl: state.url } });

    return false;

  }
}
