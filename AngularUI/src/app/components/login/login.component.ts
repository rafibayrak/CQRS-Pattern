import { Component, OnInit } from '@angular/core';
import { Login } from 'src/app/models';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  login = new Login();
  constructor(
    private _authService: AuthService
  ) { }

  ngOnInit() {
  }

  onClick() {
    this._authService.authentication(this.login).subscribe(
      result => {
        console.log(result);
      },
      error => {

      }
    );
  }
}
