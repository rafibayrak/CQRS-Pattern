import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Login } from 'src/app/models';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  emailFormControl = new FormControl('', [Validators.required]);
  passwordFormControl = new FormControl('', [Validators.required]);
  login = new Login();
  constructor(
    private _authService: AuthService,
    private _router: Router
  ) { }

  ngOnInit() {
  }

  onClick() {
    if (!this.emailFormControl.valid || !this.passwordFormControl.valid) {
      return;
    }

    this.login.userName = this.emailFormControl.value;
    this.login.password = this.passwordFormControl.value;
    this._authService.authentication(this.login).subscribe(
      result => {
        this._router.navigate(['/home']);
      },
      error => {

      }
    );
  }
}
