import { Component, OnInit } from '@angular/core';
import { ReleaseInfo } from '@chustasoft/cs-releasy-connector';
import { ReleaseService } from '../release.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {


  public releaseInfo: ReleaseInfo[];


  constructor(private releaseService: ReleaseService) {
  }


  async ngOnInit(): Promise<void> {
    this.releaseInfo = await this.releaseService.getAll();
    debugger;
  }

}
