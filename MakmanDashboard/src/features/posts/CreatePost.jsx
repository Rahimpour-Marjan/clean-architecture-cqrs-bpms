import { FormLabel } from '../../components';
import { CreateEditPostForm } from './CreateEditPostForm';

export const CreatePost = () => {
  return (
    <div>
      <FormLabel label='New post' />
      <CreateEditPostForm />
    </div>
  );
};
