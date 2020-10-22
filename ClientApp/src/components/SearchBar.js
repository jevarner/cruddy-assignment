import React, { Component } from 'react';
import { FormGroup, Form, Col, Input, Label } from 'reactstrap';

export class SearchBar extends Component {
  static displayName = SearchBar.name

  constructor(props) {
    super(props);

    this.state = { searchType: "Id", loading: true}
  }

  componentDidMount() {
    this.renderSearchBar();
  }

  renderSearchBar() {
    if (this.state.searchType == "Id") {
    }
  }

  render() {
    let contents = this.state.loading
    ? <p><em>Loading...</em></p>
    : SearchBar.renderSearchBar()


  }
}