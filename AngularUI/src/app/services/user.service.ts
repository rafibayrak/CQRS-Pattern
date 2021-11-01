import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class UserService {
  baseApi: string;
  constructor(
    private httpClient: HttpClient
  ) {
    this.baseApi = 'api/user';
  }

  getUser() {
    return this.httpClient.get(this.baseApi);
  }
}
