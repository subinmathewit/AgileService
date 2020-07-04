import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StoryService {
  private mainUrl = environment.apiUrl;
  private addStoryUrl = "story/add"
  private getAllStoriesUrl="story/GetAll"
  private autoSelectStoryurl="story/GetAutoSelect?storyPoint="
  private removeAllStoriesUrl="story/RemoveAll";
  constructor(private _http: HttpClient) {

  }

  addStory(story: Story) {
    return this._http.post(this.mainUrl + this.addStoryUrl,story);
  }

  getStories(){
    return this._http.get(this.mainUrl + this.getAllStoriesUrl);
  }

  autoSelectStory(storyPoint:Number){
    return this._http.get(this.mainUrl +this.autoSelectStoryurl+storyPoint);
  }

  removeAllStories(){
    return this._http.delete(this.mainUrl +this.removeAllStoriesUrl);
  }

}

export interface Story {
  id:Number;
  storyName: string;
  storyPoint: Number;
}
