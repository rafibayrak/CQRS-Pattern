import { MatCardModule } from '@angular/material/card';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import {MatExpansionModule} from '@angular/material/expansion';
import { AsideLeftMenuComponent } from '../helper/aside-left-menu/aside-left-menu.component';

@NgModule({
  imports: [
    CommonModule,
    MatSidenavModule,
    MatIconModule,
    MatButtonModule,
    HomeRoutingModule,
    MatListModule,
    MatCardModule,
    MatExpansionModule
  ],
  declarations: [
    HomeComponent,
    AsideLeftMenuComponent
  ],
})
export class HomeModule { }
