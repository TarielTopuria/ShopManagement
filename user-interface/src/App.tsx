import './App.css';
import MainPage from './Components/MainPage';
import ChartComponent from './Components/Chart/ChartComponent';
import { Routes, Route, BrowserRouter } from 'react-router-dom';

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<MainPage />} />
        <Route path="/chart" element={<ChartComponent />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
