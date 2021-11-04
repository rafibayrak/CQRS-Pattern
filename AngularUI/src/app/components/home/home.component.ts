import { trigger, state, style, transition, animate } from '@angular/animations';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { SideNavService } from 'src/app/services';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  animations: [
    trigger('popOverState',
      [
        state('open', style({
          'position': 'absolute',
          'bottom': 0,
          'margin-left': '350px',
          'z-index': 100,
          'margin-bottom': '20px'
        })),
        state('close', style({
          'position': 'absolute',
          'bottom': 0,
          'margin-left': '50px',
          'z-index': 100,
          'margin-bottom': '20px'
        })),
        transition('open => close', animate('200ms')),
        transition('close => open', animate('200ms'))
      ]
    )
  ]
})
export class HomeComponent implements OnInit {
  title = 'AngularUi';
  asideBar = 'aside-bar-open-btn';
  @ViewChild('sidenav') public sidenav: MatSidenav;

  constructor(private sidenavService: SideNavService) {
  }

  ngOnInit() {
  }

  ngAfterViewInit(): void {
    this.sidenavService.setSidenav(this.sidenav);
  }

  onClick() {
    this.sidenavService.toggle();
  }

  getStateName() {
    return this.sidenavService.asideOpened;
  }

  isOpened() {
    return this.sidenavService.isOpened();
  }
}
