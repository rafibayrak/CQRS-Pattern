import { Injectable } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';

@Injectable({ providedIn: 'root' })
export class SideNavService {
  constructor() { }
  private sidenav: MatSidenav;
  opened = true;

  public setSidenav(sidenav: MatSidenav) {
    this.sidenav = sidenav;
  }

  public toggle(): void {
    this.sidenav.toggle();
    this.opened = !this.opened;
  }

  get asideOpened() {
    return this.opened ? 'open' : 'close';
  }

  isOpened() {
    return this.opened;
  }
}
