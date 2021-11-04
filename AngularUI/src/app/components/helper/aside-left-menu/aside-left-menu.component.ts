import { Component, OnInit, ViewChild } from '@angular/core';
import { MatAccordion } from '@angular/material/expansion';

@Component({
  selector: 'app-aside-left-menu',
  templateUrl: './aside-left-menu.component.html',
  styleUrls: ['./aside-left-menu.component.scss']
})
export class AsideLeftMenuComponent implements OnInit {
  @ViewChild(MatAccordion) accordion: MatAccordion;
  constructor() { }

  ngOnInit() {
  }

}
