import React, { Component } from 'react';
import { BrowserRouter as Router, Switch } from 'react-router-dom';

// Services
import { AuthContextProvider } from './Services/AuthContext';
import { AppRoute } from './Services/AppRoute';

// Layouts
import { Auth } from './layouts/auth/Auth';
import { Home } from './layouts/home/Home';
import { Application } from './layouts/app/Application';

// Pages
import { HomePage } from './pages/home/HomePage';
import { LoginPage } from './pages/auth/Login';
import { RegisterPage } from './pages/auth/Register';
import { ForgotPassword } from './pages/auth/ForgotPassword';
import { Empty } from './pages/app/Empty';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <AuthContextProvider>
        <Router forceRefresh={true}>
            <Switch>
              <AppRoute exact path="/" component={HomePage} layout={Home} />
              <AppRoute exact path="/app" component={Empty} layout={Application} type="authenticated" />
              <AppRoute exact path="/auth/login" component={LoginPage} layout={Auth} />
              <AppRoute exact path="/auth/register" component={RegisterPage} layout={Auth} />
              <AppRoute exact path="/auth/forgot-password" component={ForgotPassword} layout={Auth} />
            </Switch>
        </Router>
      </AuthContextProvider>
    );
  }
}