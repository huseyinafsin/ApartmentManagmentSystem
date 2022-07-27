import './App.css';
import {BrowserRouter as Router, Route} from 'react-router-dom'
import ResidentLayout from './layout/resident';
import ManagerHeader from './components/managerHeader';
import ResidentHeader from './components/residentHeader';
import ManagerLayout from './layout/manager';

const AppRoute =({componet:Component, layout: Layout, ...rest})=>(
  <Route {...rest} render={props=>(
    <Layout>
      <Component {...props}></Component>
    </Layout>
  )}>

  </Route>
)
function App() {
  return (
   <Router>
    <AppRoute path='/manager' exact layout={ManagerLayout} componet={ManagerHeader} />
    <AppRoute path='/resident' exact layout={ResidentLayout} componet={ResidentHeader} />
   </Router>
  
  );
}

export default App;
