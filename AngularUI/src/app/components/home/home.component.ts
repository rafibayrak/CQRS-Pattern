import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(userService: UserService) {
    userService.getUser().subscribe(
      result => {
        console.log(result);
      }, error => {
        console.log(error);
      }
    );
  }

  ngOnInit() {
  }

}
