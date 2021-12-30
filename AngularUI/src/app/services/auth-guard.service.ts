import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { AuthService } from './auth.service';

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
  constructor(
    private _authService: AuthService,
    private _router: Router
  ) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    return this._authService.checkAuth().pipe(
      map(m => {
        debugger;
        return true;
      }),
      catchError(m =>{
        this._router.navigate(['login']);
        return of(false);
      })
    );
  }
}
