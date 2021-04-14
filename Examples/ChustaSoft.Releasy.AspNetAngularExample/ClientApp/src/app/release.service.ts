import { Inject, Injectable } from '@angular/core';
import { BasicAuthentication, JwtAuthentication } from '@chustasoft/cs-common';
import { ReleaseInfoService } from '@chustasoft/cs-releasy-connector';

@Injectable({
  providedIn: 'root'
})
export class ReleaseService extends ReleaseInfoService {

  //Example with BasicAuthentication
  getAuthentication(): JwtAuthentication | BasicAuthentication {
    return new BasicAuthentication("username", "user-password");
  }

  //Example with JwtAuthentication
  //getAuthentication(): JwtAuthentication | BasicAuthentication {
  //  return new JwtAuthentication("encrypted-token");
  //}

  constructor(@Inject('BASE_URL') baseUrl: string)
  {
    super(baseUrl + 'api');
  }

}
