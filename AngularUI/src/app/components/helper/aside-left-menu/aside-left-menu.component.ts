import { trigger } from '@angular/animations';
import { MatSelectionListChange } from '@angular/material/list';
import { Component, Input, OnInit, ViewChild, ChangeDetectorRef, Output, EventEmitter } from '@angular/core';
import { MatAccordion } from '@angular/material/expansion';
import { AsideLeftMenuContent } from 'src/app/models/aside-left-menu-content';
import { leftMenuFakeValue, leftMenuFakeValue2 } from './left-menu-fake-content';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-aside-left-menu',
  templateUrl: './aside-left-menu.component.html',
  styleUrls: ['./aside-left-menu.component.scss']
})
export class AsideLeftMenuComponent implements OnInit {
  @ViewChild(MatAccordion) accordion: MatAccordion;
  @Output() selectedRouteText = new EventEmitter<string>();
  @Input() selectMainMenuValue: Observable<number>;
  selectedParentIds = new Array<number>();
  menuList: Array<AsideLeftMenuContent>;
  filter: string;
  constructor() {
    this.selectedParentIds.push(0);
  }

  ngOnInit() {
    this.selectMainMenuValue.subscribe(mainMenuValue => {
      this.selectedParentIds = new Array<number>();
      this.selectedParentIds.push(0);
      switch (mainMenuValue) {
        case 1:
          this.menuList = leftMenuFakeValue;
          break;
        case 2:
          this.menuList = leftMenuFakeValue2;
          break;
      }
    });
  }

  selectionMenu(event: AsideLeftMenuContent) {
    this.selectedParentIds.push(event.id);
  }

  getMenus() {
    return this.menuList?.filter(x => x.parentId === this.selectedParentIds[this.selectedParentIds.length - 1]);
  }

  getSubMenu(item: AsideLeftMenuContent) {
    const values = this.menuList?.filter(x => x.parentId === item.id);
    return values;
  }

  routerLink(item: any) {
    this.selectedRouteText.emit(item.linkName);
  }

  backClick() {
    this.selectedParentIds.pop();
  }

  isActiveBackButton() {
    return this.selectedParentIds?.length > 1;
  }
}
