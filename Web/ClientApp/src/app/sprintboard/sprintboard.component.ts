import { Component, OnInit, Input } from '@angular/core';
import { Story } from '../services/story.service';

@Component({
  selector: 'app-sprintboard',
  templateUrl: './sprintboard.component.html',
  styleUrls: ['./sprintboard.component.css']
})
export class SprintboardComponent implements OnInit {

  @Input()
  storyList:Array<Story>=new Array<Story>();
  
  constructor() { }

  ngOnInit() {
  }

}
