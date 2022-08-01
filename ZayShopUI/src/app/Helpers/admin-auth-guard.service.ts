import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { NonVolatileService } from '../Services/non-volatile.service';

@Injectable({
  providedIn: 'root'
})
export class AdminAuthGuardService implements CanActivate {

  constructor(
    private router: Router,
    private nonVolatile: NonVolatileService
  ) { }

  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    const user = this.nonVolatile.userValue;

    if (user.role == 'Admin') {
      // authorised so return true
      return true;
    }
    // not logged in so redirect to login page with the return url
    this.router.navigate(['/users/login'], { queryParams: { returnUrl: state.url } });
    return false;

  }
}
