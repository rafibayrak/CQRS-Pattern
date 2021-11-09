import { Injectable } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { AsideMainMenu } from '../models';

@Injectable({ providedIn: 'root' })
export class SideNavService {
  constructor() { }
  private sidenav: MatSidenav;
  leftState = true;
  opened = true;

  public setSidenav(sidenav: MatSidenav) {
    this.sidenav = sidenav;
  }

  public toggle(asideMainMenu?: AsideMainMenu) {
    switch (asideMainMenu) {
      case AsideMainMenu.Close:
        if (this.sidenav.opened) {
          this.sidenav.toggle();
        }

        this.opened = false;
        return;
      case AsideMainMenu.Open:
        if (!this.sidenav.opened) {
          this.sidenav.toggle();
        }

        this.opened = true;
        return;
    }

    this.sidenav.toggle();
    this.opened = !this.opened;
  }

  get asideOpened() {
    if (!this.leftState) {
      return this.opened ? 'openAside' : 'closeAside';
    }

    return this.opened ? 'open' : 'close';
  }

  toogleLeftMenu(asideMainMenu?: AsideMainMenu) {
    switch (asideMainMenu) {
      case AsideMainMenu.Close:
        this.leftState = false;
        return;
      case AsideMainMenu.Open:
        this.leftState = true;
        return;
    }

    this.leftState = !this.leftState;
  }

  get leftMenuOpened() {
    return this.leftState ? 'open' : 'close';
  }

  isOpened() {
    return this.opened;
  }
}
