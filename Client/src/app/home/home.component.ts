import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
registerMode:Boolean = false;
users: any;

  constructor() { }

  ngOnInit(): void {
 
  }

  registerToggle(){
    this.registerMode = !this.registerMode;
  }
 
  cancelRegisterMode(event: Boolean){
    this.registerMode = event;
  }
  
}
