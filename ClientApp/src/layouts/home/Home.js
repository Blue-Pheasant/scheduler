import { Component } from 'react';
import React  from 'react';

// Components import
import { Bootstrap } from './components/Bootstrap';

// Import style
import "./static/css/ud-styles.css";
import "./static/css/lineicons.css";

export class Home extends Component {
  render() {
    return (
      <>
        <Bootstrap />
        {this.props.children}
      </>
    );
  }
}
