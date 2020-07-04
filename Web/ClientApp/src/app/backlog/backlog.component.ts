import { Component, OnInit, Input } from '@angular/core';
import { Story } from '../services/story.service';


@Component({
  selector: 'app-backlog',
  templateUrl: './backlog.component.html',
  styleUrls: ['./backlog.component.css']
})
export class BacklogComponent implements OnInit { 
  @Input()
  backLogList:Array<Story>=new Array<Story>();
  
  constructor() { }

  ngOnInit() {    
  }
  

}
