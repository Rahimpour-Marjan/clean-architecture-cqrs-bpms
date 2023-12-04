import { createBrowserRouter } from 'react-router-dom';
import { AppLayout, PageNotFound } from './components';
import { CreatePost, Posts } from './features/posts';
import { EditPost } from './features/posts/EditPost';
import { Registration } from './features/registration';
import { Login } from './features/login';

export const router = createBrowserRouter([
  {
    path: '/',
    element: <Login />,
    children: [
      {
        path: '/login',
      },
    ],
  },
  {
    path: '/registration',
    element: <Registration />,
  },
  {
    path: '/posts',
    element: <AppLayout />,
    children: [
      {
        index: true,
        element: <Posts />,
      },
      {
        path: 'create',
        element: <CreatePost />,
      },
      {
        path: 'edit/:postId',
        element: <EditPost />,
      },
    ],
  },
  {
    path: '*',
    element: <PageNotFound />,
  },
]);
