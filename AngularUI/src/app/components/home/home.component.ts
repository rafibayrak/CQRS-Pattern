import { trigger, state, style, transition, animate } from '@angular/animations';
import { ChangeDetectorRef, Component, HostBinding, HostListener, OnInit, ViewChild } from '@angular/core';
import { MatDrawerMode, MatSidenav } from '@angular/material/sidenav';
import { SideNavService } from 'src/app/services';
import { OverlayContainer } from '@angular/cdk/overlay';
import { Subject } from 'rxjs';
import { AsideMainMenu } from 'src/app/models';

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
          'margin-bottom': '50px'
        })),
        state('close', style({
          'position': 'absolute',
          'bottom': 0,
          'margin-left': '50px',
          'z-index': 100,
          'margin-bottom': '50px'
        })),
        transition('open => close', animate('200ms')),
        transition('close => open', animate('200ms')),
        state('openAside', style({
          'position': 'absolute',
          'bottom': 0,
          'margin-left': '275px',
          'z-index': 100,
          'margin-bottom': '50px'
        })),
        state('closeAside', style({
          'position': 'absolute',
          'bottom': 0,
          'margin-left': '50px',
          'z-index': 100,
          'margin-bottom': '50px'
        })),
        transition('openAside => closeAside', animate('200ms')),
        transition('closeAside => openAside', animate('200ms')),
        transition('openAside => open', animate('200ms')),
        transition('open => openAside', animate('200ms')),
        transition('close => closeAside', animate('200ms')),
        transition('closeAside => close', animate('200ms'))
      ]
    )
  ]
})
export class HomeComponent implements OnInit {
  eventsSubject: Subject<number> = new Subject<number>();
  selectedMainMenuSubject: Subject<number> = new Subject<number>();
  headerTextSubject: Subject<string> = new Subject<string>();
  height: number;
  contentHeight: number;
  isMediumWidht = false;
  modeSide: MatDrawerMode;

  @ViewChild('sidenav') public sidenav: MatSidenav;
  constructor(
    private _sidenavService: SideNavService,
    private overlay: OverlayContainer,
    private _ref: ChangeDetectorRef
  ) {
    this.changeToggle(localStorage.getItem('theme') !== 'dark')
    this.resize();
  }

  ngOnInit() { }

  isLower = true;
  ngAfterViewInit(): void {
    this._sidenavService.setSidenav(this.sidenav);
    this.drawerSize();
    this.eventsSubject.next(this.height);
    this._ref.detectChanges();
  }

  onClick() {
    this._sidenavService.toggle();
    if (innerWidth < 720) {
      !this._sidenavService.isOpened() ? this._sidenavService.toogleLeftMenu(AsideMainMenu.Open) : this._sidenavService.toogleLeftMenu(AsideMainMenu.Close);
    }
  }

  getStateName() {
    return this._sidenavService.asideOpened;
  }

  isOpened() {
    return this._sidenavService.isOpened();
  }


  @HostListener('window:resize', ['$event']) resize() {
    this.height = innerHeight - 100;
    this.eventsSubject.next(this.height);
    this.contentHeight = innerHeight - 144;
    this.drawerSize();
  }

  drawerSize() {
    if (this.sidenav) {
      this.modeSide = innerWidth <= 720 ? 'over' : 'side';
      if (innerWidth <= 720 && this.isLower) {
        this._sidenavService.toggle(AsideMainMenu.Close);
        this._sidenavService.toogleLeftMenu(AsideMainMenu.Close);
        this.isLower = false;
        this._ref.detectChanges();
      } else if (innerWidth > 720 && !this.isLower) {
        this._sidenavService.toggle(AsideMainMenu.Open);
        this._sidenavService.toogleLeftMenu(AsideMainMenu.Open);
        this.isLower = true;
        this._ref.detectChanges();
      }
    }
  }

  @HostBinding('class') className = '';
  changeToggle(darkMode: boolean) {
    const darkClassName = 'theme-alternate';
    this.className = darkMode ? darkClassName : '';
    if (darkMode) {
      localStorage.setItem('theme', 'light');
      this.overlay.getContainerElement().classList.add(darkClassName);
    } else {
      localStorage.setItem('theme', 'dark');
      this.overlay.getContainerElement().classList.remove(darkClassName);
    }
  }

  selectedMainMenu(mainMenuValue: number) {
    this.selectedMainMenuSubject.next(mainMenuValue);
  }

  selectedRouteText(event: string) {
    this.headerTextSubject.next(event);
  }
}