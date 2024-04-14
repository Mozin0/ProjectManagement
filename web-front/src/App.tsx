import 'tailwindcss/tailwind.css'
import { Toaster } from './components/ui/toaster'
import AppRoutes from './routes/routes'

function App() {
  return (
    <>
      <AppRoutes />
      <Toaster />
    </>
  )
}

export default App
