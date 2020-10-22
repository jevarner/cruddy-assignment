import React, { Component } from 'react';
import { SearchMenu} from './SearchMenu';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <SearchMenu></SearchMenu>
      </div>
    );
  }
}
