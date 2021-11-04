import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { CommonFormModule } from 'src/app/modules/common-form.module';
import { LoginRoutingModule } from './login-routing.module';
import { LoginComponent } from './login.component';
import { MatGridListModule } from '@angular/material/grid-list';

@NgModule({
  imports: [
    CommonModule,
    LoginRoutingModule,
    CommonFormModule,
    MatGridListModule
  ],
  exports: [],
  declarations: [LoginComponent],
  providers: [],
})
export class LoginModule { }
