import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Login } from '../models';

@Injectable({ providedIn: 'root' })
export class AuthService {
  apiUrl: string;
  constructor(
    private httpClient: HttpClient
  ) {
    this.apiUrl = 'api/Auth'
  }

  authentication(login: Login) {
    return this.httpClient.post(this.apiUrl, login);
  }
}
