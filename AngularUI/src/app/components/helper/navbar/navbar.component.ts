import { Observable } from 'rxjs';
import { FormControl } from '@angular/forms';
import { Component, EventEmitter, HostBinding, Input, OnInit, Output } from '@angular/core';
import { SideNavService } from 'src/app/services';
import { OverlayContainer } from '@angular/cdk/overlay';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  @Output() changeToggle = new EventEmitter<boolean>();
  @Input() headerTextObs = new Observable<string>();
  headerText: string;
  constructor(
    private _sideNavService: SideNavService) { }
  toggleValue = new FormControl('dark');
  ngOnInit() {
    this.toggleValue.setValue(localStorage.getItem('theme'));
    this.toggleValue.valueChanges.subscribe((darkMode: string) => {
      const isNotDark = darkMode !== 'dark';
      this.changeToggle.emit(isNotDark);
    });

    this.headerTextObs.subscribe(data => {
      this.headerText = data;
    });
  }

  onClick() {
    this._sideNavService.toogleLeftMenu();
  }
}
