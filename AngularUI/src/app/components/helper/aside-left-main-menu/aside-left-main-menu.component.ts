import { trigger, state, style, transition, animate } from '@angular/animations';
import { AfterViewInit, Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { MatSelectionListChange } from '@angular/material/list';
import { Observable, Subscription } from 'rxjs';
import { SideNavService } from 'src/app/services';

@Component({
  selector: 'app-aside-left-main-menu',
  templateUrl: './aside-left-main-menu.component.html',
  styleUrls: ['./aside-left-main-menu.component.scss'],
  animations: [
    trigger('leftMenuState',
      [
        state('open', style({
          'width': '75px',
          'position': 'relative',
          'min-width': '75px'
        })),
        state('close', style({
          'width': '0px',
          'position': 'relative',
          'min-width': '0px'
        })),
        transition('open => close', animate('200ms')),
        transition('close => open', animate('200ms'))
      ])
  ]
})
export class AsideLeftMainMenuComponent implements OnInit, AfterViewInit {
  @ViewChild('widgetsContent', { static: false }) widgetsContent: any;
  @Input() events: Observable<number>;
  private eventsSubscription: Subscription;
  @Output() selectedMainMenu = new EventEmitter<number>();
  height: number;
  scrollDownId: any;
  deneme = [1];
  scrollUpId: any;
  angularLeftMenu = [
    { icon: 'home', toolTipText: 'Home', value: 1 },
    { icon: 'send', toolTipText: 'Send', value: 2 },
    { icon: 'outlet', toolTipText: 'Outlet', value: 3 }
  ];
  constructor(
    private _sidenavService: SideNavService
  ) {
  }

  ngOnInit() {
    this.eventsSubscription = this.events.subscribe(data => {
      this.height = data;
    });
  }

  ngAfterViewInit() {
    if (this.widgetsContent) {
      console.log(this.widgetsContent);
    }
    this.deneme = [this.angularLeftMenu[0].value];
    this.selectedMainMenu.emit(this.deneme[0]);
  }

  scrollTopDown() {
    this.scrollUpId = setInterval(() => {
      this.widgetsContent._element.nativeElement.scrollTop -= 3;
    }, 20);
  }

  scrollTopUp() {
    clearInterval(this.scrollUpId);
  }

  scrollBottomDown() {
    this.scrollDownId = setInterval(() => {
      this.widgetsContent._element.nativeElement.scrollTop += 3;
    }, 20);

  }

  scrollBottomUp() {
    clearInterval(this.scrollDownId);
  }

  getLeftMenuStateName() {
    return this._sidenavService.leftMenuOpened;
  }

  selectionChange(event: MatSelectionListChange) {
    const value = event?.source?._value;
    const selectedValue = value ? Number.parseInt(value[0]) : this.angularLeftMenu[0].value;
    if (!this._sidenavService.isOpened()) {
      this._sidenavService.toggle();
      if (innerWidth < 720) {
        this._sidenavService.toogleLeftMenu();
      }
    }

    this.selectedMainMenu.emit(selectedValue);
  }
}
