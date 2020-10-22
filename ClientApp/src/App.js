import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { GetMaxCost } from './components/GetMaxCost';
import { GetItemMaxCost } from './components/GetItemMaxCost';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  createMaxCost = (event) => {
    
  }

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/get-max-cost' component={GetMaxCost} />
        <Route path='/get-max-cost-by-item' component={GetItemMaxCost} />
      </Layout>
    );
  }
}
