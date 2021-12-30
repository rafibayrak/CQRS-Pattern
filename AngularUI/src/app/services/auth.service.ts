import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Login } from '../models';
import { ControllerService } from './controler.service';

@Injectable({ providedIn: 'root' })
export class AuthService extends ControllerService {
  constructor(
    httpClient: HttpClient,
    _router: Router
  ) {
    super('Auth', httpClient, _router);
  }

  authentication(login: Login) {
    return this.post('', login);
  }

  checkAuth(){
    return this.get('/checkAuth');
  }
}
