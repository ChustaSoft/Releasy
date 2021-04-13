import { Inject, Injectable } from '@angular/core';
import { BasicAuthentication, JwtAuthentication } from '@chustasoft/cs-common';
import { ReleaseInfoService } from '@chustasoft/cs-releasy-connector';

@Injectable({
  providedIn: 'root'
})
export class ReleaseService extends ReleaseInfoService {

  //Example with BasicAuthentication
  getAuthentication(): JwtAuthentication | BasicAuthentication {
    return { username: "XXX", password: "YYY" } as BasicAuthentication;
  }

  //Example with JwtAuthentication
  //getAuthentication(): JwtAuthentication | BasicAuthentication {
  //  return { token: "encrypted-token" } as JwtAuthentication;
  //}

  constructor(@Inject('BASE_URL') baseUrl: string)
  {
    super(baseUrl + 'api');
  }

}
