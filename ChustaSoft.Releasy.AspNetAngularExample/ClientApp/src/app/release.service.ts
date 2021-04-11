import { Inject, Injectable } from '@angular/core';
import { BasicAuthentication } from '@chustasoft/cs-common';
import { ReleaseInfoService } from '@chustasoft/cs-releasy-connector';

@Injectable({
  providedIn: 'root'
})
export class ReleaseService extends ReleaseInfoService {

  getAuthentication(): string | BasicAuthentication {
    return "";
  }

  constructor(@Inject('BASE_URL') baseUrl: string)
  {
    super(baseUrl + 'api');
  }

}
