import { HttpEvent, HttpHandler, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { NonVolatileService } from '../Services/non-volatile.service';


@Injectable({
  providedIn: 'root'
})
export class ErrorInterceptorService {

  constructor(private nonVolatile: NonVolatileService) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(catchError(err => {
        if ([401, 403].includes(err.status) && this.nonVolatile.GetDataToLocalStorage()) {
            // auto logout if 401 or 403 response returned from api
            // this.accountService.logout();
        }

        const error = err.error?.message || err.statusText;
        console.error(err);
        return throwError(() => error);
    }))
}
}
