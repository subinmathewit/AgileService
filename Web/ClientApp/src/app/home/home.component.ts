import { Component, OnInit, ViewChild } from '@angular/core';
import { StoryService, Story } from '../services/story.service';
import { BacklogComponent } from '../backlog/backlog.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {

  story: Story = {} as Story;
  stories: Array<Story> = new Array<Story>();
  autoSelectStories: Array<Story> = new Array<Story>();
  storyPointLimit: Number;
  @ViewChild(BacklogComponent, { static: false }) private backLogComponent: BacklogComponent;
  constructor(private _storyService: StoryService) {

  }
  ngOnInit(): void {
    this.initializeComponent();
  }
  onAddStory() {

    this._storyService.addStory(this.story).subscribe((data: any) => {
      var obj = {} as Story;
      obj.storyName = this.story.storyName;
      obj.storyPoint = this.story.storyPoint;
      this.stories.push(obj);

    }, err => {

    });
  }
  onAutoSelectStory() {
    this._storyService.autoSelectStory(this.storyPointLimit).subscribe((data: any) => {     
      this.autoSelectStories=data;
     
    },
      err => {

      });
  }
  onClearAllStory() {
    this._storyService.removeAllStories().subscribe((data: any) => {
      this.stories = null;
      this.stories=new Array<Story>();
    },
      err => {

      });
  }
  onClearSprint() {
    this.autoSelectStories = null;
  }
  private initializeComponent() {
    this._storyService.getStories().subscribe((data: any) => {
      this.stories = data;
    }, err => {

    })
  }
}

