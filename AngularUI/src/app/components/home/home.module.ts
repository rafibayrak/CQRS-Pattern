import { CommonFormModule } from 'src/app/modules/common-form.module';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatTooltipModule } from '@angular/material/tooltip';
import { AsideLeftMenuComponent } from '../helper/aside-left-menu/aside-left-menu.component';
import { NavbarComponent } from '../helper/navbar/navbar.component';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { AsideLeftMainMenuComponent } from '../helper/aside-left-main-menu/aside-left-main-menu.component';
import { CommonPipeModule } from 'src/app/pipes/common-pipe.module';

@NgModule({
  imports: [
    CommonModule,
    MatSidenavModule,
    HomeRoutingModule,
    MatListModule,
    CommonFormModule,
    MatExpansionModule,
    MatTooltipModule,
    MatButtonToggleModule,
    CommonPipeModule
  ],
  declarations: [
    HomeComponent,
    AsideLeftMenuComponent,
    NavbarComponent,
    AsideLeftMainMenuComponent
  ],
})
export class HomeModule { }
